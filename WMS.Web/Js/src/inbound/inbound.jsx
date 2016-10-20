class StockInLines extends React.Component {
    constructor(props) {
        super(props);
        this.state = { lines: this.props.lines };
    }

    render() {     
        var items = this.state.lines.map(function (data, i) {
            return (<tr key={i}><td key={i}>{data.Barcode}</td><td>{data.CartonNo}</td></tr>);
        });

        return (
            <div>
                <table className="table table-bordered table-striped table-condensed table-responsive datatable datatable-paging">
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
            <div>
                <div className="panel panel-default">
                    <div className="panel-body">
                         <div className="row">
                            <div className="col-md-2">Plant:</div>
                            <div className="col-md-10">{this.props.data.Plant}</div>
                                 </div>
                         <div className="row">
                            <div className="col-md-2">Location:</div>
                            <div className="col-md-10">{this.props.data.DestLocation}</div>
                         </div>
                         <div className="row">
                            <div className="col-md-2">Inhouse No:</div>
                            <div className="col-md-10">{this.props.data.DocNo}</div>
                         </div>
                         <div className="row">
                            <div className="col-md-2">Wip No:</div>
                            <div className="col-md-10">{this.props.data.WipNo}</div>
                         </div>
                         <div className="row">
                            <div className="col-md-2">Part Number:</div>
                            <div className="col-md-10">{this.props.data.PartNumber}</div>
                         </div>
                         <div className="row">
                            <div className="col-md-2">Qty:</div>
                            <div className="col-md-10">{this.props.data.Quantity}</div>
                         </div>
                         <div className="row">
                            <div className="col-md-2">DestPlant:</div>
                            <div className="col-md-10">{this.props.data.DestPlant}</div>
                         </div>
                         <div className="row">
                            <div className="col-md-2">DestLocation:</div>
                            <div className="col-md-10">{this.props.data.DestLocation}</div>
                         </div>
                    </div>
                </div>
               
                <StockInLines lines={this.props.data.StockInLines} />
            </div>
        );
    }
}