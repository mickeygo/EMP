
// React Test Demo
var HelloWorld = React.createClass({
    render: function() {
        return (
          <div className="commentBox">
            Wellcome to react world !
          </div>
      );
    }
});

class HelloMessage extends React.Component {
    render() {
        return (
            <div className="commentBox">
                Wellcome to react world !
                {this.props.name}
            </div>
        );
    }
};
