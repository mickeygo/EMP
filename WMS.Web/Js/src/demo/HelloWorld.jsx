
// React Test Demo

// ES5
var HelloWorld = React.createClass({
    render: function() {
        return (
          <div className="commentBox">
            Wellcome to react world ! {this.props.message}
          </div>
      );
    }
});

// ES6
class News extends React.Component {
    render() {
        return (
            <li>{this.props.name}</li>
        );
    }
};

class HelloMessage extends React.Component {
    constructor(props) {
        super(props);
        this.state = { example: 'example' }
    }

    render() {
        var newsList = [1, 2, 3].map(function (news) {
            return (<News name={news} />);
        });

        return (
            <div className="commentBox">
               <ul>
                   {newsList}
               </ul>
            </div>
        );
    }
};