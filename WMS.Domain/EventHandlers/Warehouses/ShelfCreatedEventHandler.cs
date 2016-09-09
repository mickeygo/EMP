using System;
using DotPlatform.Events;
using WMS.Domain.Events.Warehouses;
using DotPlatform.Domain.Uow;
using WMS.Domain.Repositories;
using WMS.Domain.Models.Warehouses;
using DotPlatform.Domain.Entities.Extensions;

namespace WMS.Domain.EventHandlers.Warehouses
{
    /// <summary>
    /// 仓库货架创建事件处理者
    /// </summary>
    public class ShelfCreatedEventHandler : IEventHandler<ShelfCreatedEvent>
    {
        private readonly IShelfRepository _shelfRepository;

        public ShelfCreatedEventHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        [UnitOfWork]
        public virtual void Handle(ShelfCreatedEvent e)
        {
            var shelf = e.Source.Cast<Shelf>();

            _shelfRepository.Add(shelf);
        }
    }
}
