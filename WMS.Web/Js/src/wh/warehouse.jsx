
// WareHouse
class Warehouse extends React.Component {
    constructor(props) {
        super(props);
        //this.state = { example: 'example' }
    }

    editWh(e) {
        e.preventDefault();
    }

    deleteWh(e) {
        e.preventDefault();
    }

    render() {
        return (
                <div>
                    <div className="btn btn-primary">
                        <div className="col-md-8">
                            <input type="radio" name="options" value="" />
                            <i className="glyphicon glyphicon-home"></i> {this.props.source.DisplayName}
                        </div>
                     </div>
                </div>
            );
    }
};

// Warehouse 集合
class WarehouseCollection extends React.Component {
    constructor(props) {
        super(props);

        this.state = {};
    }

    componentDidMount() {
        $.getJSON();
    }

    render() {
        var whlist = this.props.warehouses.map(function (wh) {
            return <Warehouse source={wh} />;
        });

        return (
            <div>
               <div class="btn-group" data-toggle="buttons">
                    {whlist}
                    <a className="btn btn-primary">
                        <i className="glyphicon glyphicon-plus"></i>
                    </a>
               </div>
            </div>
        );
    }
};

//ReactDOM.render(
//    <WarehouseCollection souce={$.getJSON("")} />,
//    document.getElementById("content3")
//);
