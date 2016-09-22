
/*===================== WareHouse ======================*/

var WarehouseEvent = {
    warehouse: "warehouse_event_0.1",
    zone: "zone_event_0.1",
    shelf: "shelf_event_0.1",
    location: "location_event_0.1",
}

class Warehouses extends React.Component {
    constructor(props) {
        super(props);
    }

    whChoseHandler(e) {
        var whId = this.refs.wh.value;
        EventEmitter.dispatch(WarehouseEvent.warehouse, whId);
        console.log("warehouse id:", whId);
    }

    render() {
        return (
            <div className="btn btn-primary" onClick={this.whChoseHandler.bind(this)}>
                <input ref="wh" type="radio" name="warehouse" value={this.props.source.Id} />
                <i className="glyphicon glyphicon-home"></i> {this.props.source.DisplayName}
            </div>
        );
    }
};

// Warehouse 集合
class WarehouseCollection extends React.Component {
    constructor(props) {
        super(props);
        this.state = { warehouses: [], eventId: Guid.newGuid() };
    }

    getAllWHs() {
        $.getJSON("/admin/warehouse/getall", function (data) {
            this.setState({ warehouses: data });
        }.bind(this));  // bind
    }

    editWHSuccess() {
        this.getAllWHs();
    }

    componentDidMount() {
        this.getAllWHs();

        EventEmitter.subscribe(this.state.eventId, function (data) {
            this.getAllWHs();
        }.bind(this));
    }

    componentWillUnmount() {
        EventEmitter.unSubscribe(this.state.eventId);
    }

    render() {
        var warehouseList = this.state.warehouses.map(function (wh, i) {
            return <Warehouses key={i} source={wh} />;
        });

        return (
            <div className="row">
                <div className="col-md-11">
                    <div className="btn-group" data-toggle="buttons">{warehouseList}
                        <a className="btn btn-primary" data-dialog="true" data-dialog-href="/admin/warehouse/create"
                           data-dialog-title="Create Warehouse" data-ajax-form="true" data-event-id={this.state.eventId}>
                            <i className="glyphicon glyphicon-plus"></i>
                        </a>
                    </div>
                </div>
               <div className="col-md-1">
                    <a className="btn btn-primary btn-xs" data-dialog="true" data-dialog-href={"/admin/warehouse/edit?id="}
                       data-dialog-form="true" data-dialog-title="Edit Warehouse" data-event-id={this.state.eventId}>
                        <i className="glyphicon glyphicon-edit"></i>
                    </a>
                    <a className="btn btn-danger btn-xs">
                        <i className="glyphicon glyphicon-trash"></i>
                    </a>
               </div>
            </div>
        );
    }
};

/*===================== Zone ======================*/

class Zone extends React.Component {
    choseHandler(data) {
        EventEmitter.dispatch(WarehouseEvent.zone, data);
        console.log("zone id:", data.zoneId);
        console.log("zone name:", data.zoneName);
    }

    render() {
        return (
             <div className="list-group-item">
                <div className="row">
                    <div className="col-md-5">
                        <a onClick={this.choseHandler.bind(this, { zoneId: this.props.source.Id, zoneName: this.props.source.Name })}>
                            {this.props.source.DisplayName}
                        </a>
                    </div>
                    <div className="col-md-7 text-right">
                        <a><i className="glyphicon glyphicon-edit"></i></a>
                        <a><i className="glyphicon glyphicon-trash"></i></a>
                    </div>
                </div>
             </div>
        );
    }
}

class ZoneCollection extends React.Component {
    constructor(props) {
        super(props);
        this.state = { zones: [], warehouseId: "", eventId: Guid.newGuid() };
    }

    getZones(whId) {
        $.getJSON("/admin/zone/getall", { whId }, function (data) {
            this.setState({ zones: data });
        }.bind(this));  // bind
    }

    componentDidMount() {
        EventEmitter.subscribe(WarehouseEvent.warehouse, function (data) {
            this.setState({ warehouseId: data });
            this.getZones(data);    // 使用 this.state.warehouseId 会获取不到数据, 因为 setState 是异步方法
            console.log("warehouse id of zone:" + data);
        }.bind(this));

        EventEmitter.subscribe(this.state.eventId, function (data) {
            this.getZones(this.state.warehouseId);
        }.bind(this));
    }

    render() {
        var zoneList = this.state.zones.map(function (zone, i) {
            return <Zone key={i} source={zone } />;
        });

        return (
             <div className="list-group">
                <a className="list-group-item active" data-dialog="true" data-dialog-href={"/admin/zone/create?whId=" + this.state.warehouseId}
                   data-dialog-title="Create Zone" data-ajax-form="true" data-event-id={this.state.eventId}>
                    <i className="glyphicon glyphicon-plus"></i>
                </a>
                 {zoneList}
             </div>
        );
    }
}

/*===================== Shelf ======================*/

class ShelfCollection extends React.Component {
    constructor(props) {
        super(props);

        this.state = { shelfs: [], zoneId: "", zoneName: "", eventId: Guid.newGuid() };
    }

    getShelfs(zoneId) {
        $.getJSON("/admin/shelf/getall", { zoneId }, function (data) {
            this.setState({ shelfs: data });
        }.bind(this));  // bind
    }

    shelfChangedHandler(e) {
        EventEmitter.dispatch(WarehouseEvent.shelf, e.target.value);
    }

    componentDidMount() {
        EventEmitter.subscribe(WarehouseEvent.zone, function (data) {
            this.setState({ zoneId: data.zoneId, zoneName: data.zoneName });
            this.getShelfs(data.zoneId);
        }.bind(this));
    }

    render() {
        var options = this.state.shelfs.map(function (sf, i) {
            return (<option key={i} value={sf.Id}>{sf.Name}</option>)
        });

        return (
            <div className="panel panel-default">
                <div className="panel-body">
                    <div className="row">
                        <div className="col-md-10 controls">
                            <span>{this.state.zoneName} : </span>
                            <select data-rel="chosen" onChange={this.shelfChangedHandler}>
                                {options}
                            </select>
                        </div>
                        <div className="col-md-2 text-right">
                            <div className="box-icon">
                                <a className="btn btn-round btn-default" data-dialog="true" data-dialog-href={"/admin/shelf/create?zoneId=" + this.state.zoneId}
                                   data-dialog-title="Create Shelf" data-ajax-form="true" data-event-id={this.state.eventId}>
                                    <i className="glyphicon glyphicon-plus"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

class ShelfDetail extends React.Component {
    constructor(props) {
        super(props);

        this.state = { shelf: {}, eventId: Guid.newGuid() };
    }

    getShelf(id) {
        $.getJSON("/admin/shelf/get", { id }, function (data) {
            this.setState({ shelf: data });
        }.bind(this));
    }

    componentDidMount() {
        EventEmitter.subscribe(WarehouseEvent.shelf, function (data) {
            this.getShelf(data);
        }.bind(this));
    }

    render() {
        return (
            <div className="panel panel-default">
                <div className="panel-heading">
                    {this.state.shelf.Name}
                    <div className="box-icon">
                        <a className="btn btn-round btn-default" data-dialog="true" data-dialog-href={"/admin/location/create?shelfId=" + this.state.shelf.Id}
                            data-dialog-title="Create Location" data-ajax-form="true" data-event-id={this.state.eventId}>
                            <i className="glyphicon glyphicon-plus"></i>
                        </a>
                        <a className="btn btn-round btn-default" data-dialog="true">
                            <i className="glyphicon glyphicon-cog"></i>
                        </a>
                        <a href="#" className="btn btn-round btn-default">
                            <i className="glyphicon glyphicon-remove"></i>
                        </a>
                    </div>
                </div>
                <div className="panel-body">
                    <div className="row">
                        <div className="col-md-8">
                            <div>
                                Volume: {this.state.shelf.Length + " * " + this.state.shelf.Width + " * " + this.state.shelf.Height} (m) 
                            </div>
                        </div>
                    </div>
                    <div style={{marginTop: "10px"}}>
                        <LocationCollection shelfId={this.state.shelf.Id} />
                    </div>
                </div>
            </div>
        );
    }
}

/*===================== Location ======================*/

class LocationCollection extends React.Component {
    constructor(props) {
        super(props);

        this.state = { locations: [] };
    }

    getLocs(shelfId) {
        $.getJSON("/admin/location/getall", { shelfId }, function (data) {
            this.setState({ locations: data });
        }.bind(this));
    }

    showLocations() {
        if (!this.state.locations.length) {
            return (<div></div>);
        }

        var locationList = this.state.locations.map(function (loc, index) {
            return (
                <tr key={index}>
                    <td>{loc.Name}</td>
                    <td>{loc.IsBonded ? "Y" : "N"}</td>
                    <td>{loc.Length + " * " + loc.Width + " * " + loc.Height + " (m)"}</td>
                    <td>
                        <a className="btn btn-primary btn-xs" data-dialog="true" data-dialog-href="/admin/warehouse/edit"
                            data-dialog-form="true" data-dialog-title="Edit Warehouse">
                            <i className="glyphicon glyphicon-edit"></i>
                         </a>
                         <a className="btn btn-danger btn-xs">
                             <i className="glyphicon glyphicon-trash"></i>
                         </a>
                     </td>
                    </tr>
            );
        });

        return (
            <table className="table table-bordered table-striped table-condensed table-responsive datatable">
                <thead>
                    <tr>
                        <th>Location</th>
                        <th>IsBonded</th>
                        <th>Volume</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {locationList}
                </tbody>
            </table>
        )
    }

    componentDidMount() {
        EventEmitter.subscribe(WarehouseEvent.shelf, function (data) {
            this.getLocs(data);
        }.bind(this));
    }

    render() {
        return this.showLocations();
    }
}