class StockInLines extends React.Component {
    constructor(props) {
        super(props);
        //this.state = { lines: this.props.lines };
    }

    render() {     
        var items = this.props.lines.map(function (data, i) {
            return (<tr key={i}><td key={i}>{data.Barcode}</td><td>{data.CartonNo}</td></tr>);
        });

        return (
            <div>
                <table className="table table-bordered table-striped table-condensed table-responsive datatable">
                    <thead>
                    <tr>
                        <th>Barcode</th>
                        <th>BoxNo</th>
                    </tr>
                    </thead>
                    <tbody>
                        {items}
                    </tbody>
                </table>
            </div>
        );
    }
}

class Inbound extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="row">
                <div className="col-md-5 col-sm-5">
                    <div className="portlet light bordered">
                        <div className="portlet-title">
                            <div className="caption font-purple-plum">
                                <i className="icon-speech font-purple-plum"></i>
                                <span className="caption-subject bold">Info</span>
                            </div>
                        </div>
                        <div className="portlet-body">
                            <div className="row">
                                <div className="col-md-4">Plant:</div>
                                <div className="col-md-8">{this.props.data.Plant}</div>
                                </div>
                             <div className="row">
                                <div className="col-md-4">Location:</div>
                                <div className="col-md-8">{this.props.data.DestLocation}</div>
                             </div>
                             <div className="row">
                                <div className="col-md-4">Inhouse No:</div>
                                <div className="col-md-8">{this.props.data.DocNo}</div>
                             </div>
                             <div className="row">
                                <div className="col-md-4">Wip No:</div>
                                <div className="col-md-8">{this.props.data.WipNo}</div>
                             </div>
                             <div className="row">
                                <div className="col-md-4">Part Number:</div>
                                <div className="col-md-8">{this.props.data.PartNumber}</div>
                             </div>
                             <div className="row">
                                <div className="col-md-4">Qty:</div>
                                <div className="col-md-8">{this.props.data.Quantity}</div>
                             </div>
                             <div className="row">
                                <div className="col-md-4">DestPlant:</div>
                                <div className="col-md-8">{this.props.data.DestPlant}</div>
                             </div>
                             <div className="row">
                                <div className="col-md-4">DestLocation:</div>
                                <div className="col-md-8">{this.props.data.DestLocation}</div>
                             </div>
                        </div>
                    </div>
                </div>
                <div className="col-md-7 col-sm-7">
                    <div className="portlet light bordered">
                         <div className="portlet-title">
                             <div className="caption font-purple-plum">
                                <i className="icon-speech font-purple-plum"></i>
                                <span className="caption-subject bold">Detail</span>
                             </div>
                         </div>
                        <div className="portlet-body">
                             <StockInLines lines={this.props.data.StockInLines} />
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}