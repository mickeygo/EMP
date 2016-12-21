using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http.Controllers;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Uow;
using DotPlatform.Domain.Repositories;

namespace DotPlatform.Web.WebApi.OData.Controllers
{
    /// <summary>
    ///基于 OData Entity 的 Web ApiController
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class DotPlatformODataEntityControllerr<TEntity, TPrimaryKey> : ODataController
        where TPrimaryKey : IEquatable<TPrimaryKey>
        where TEntity : class, IAggregateRoot<TPrimaryKey>
    {
        private IUnitOfWorkCompleteHandle _unitOfWorkCompleteHandler;
        private bool _disposed;

        public IUnitOfWorkManager UnitOfWorkManager { get; set; }

        protected IRepository<TEntity, TPrimaryKey> Repository { get; private set; }

        protected DotPlatformODataEntityControllerr(IRepository<TEntity, TPrimaryKey> repository)
        {
            Repository = repository;
        }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            _unitOfWorkCompleteHandler = UnitOfWorkManager.Begin();

            return base.ExecuteAsync(controllerContext, cancellationToken);
        }

        [EnableQuery]
        public virtual IQueryable<TEntity> Get()
        {
            return Repository.GetAll();
        }

        [EnableQuery]
        public virtual SingleResult<TEntity> Get([FromODataUri] TPrimaryKey key)
        {
            var entity = Repository.GetAll().Where(e => e.Id.Equals(key));

            return SingleResult.Create(entity);
        }

        public virtual async Task<IHttpActionResult> Post(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEntity = await Repository.AddAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return Created(createdEntity);
        }

        public virtual async Task<IHttpActionResult> Patch([FromODataUri] TPrimaryKey key, Delta<TEntity> entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbLookup = await Repository.GetAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Patch(dbLookup);

            return Updated(entity);
        }

        public virtual async Task<IHttpActionResult> Put([FromODataUri] TPrimaryKey key, TEntity update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!key.Equals(update.Id))
            {
                return BadRequest();
            }

            var updated = await Repository.UpdateAsync(update);

            return Updated(updated);
        }

        public virtual async Task<IHttpActionResult> Delete([FromODataUri] TPrimaryKey key)
        {
            var product = await Repository.GetAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            await Repository.DeleteAsync(key);

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _unitOfWorkCompleteHandler.Complete();
                _unitOfWorkCompleteHandler.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}
