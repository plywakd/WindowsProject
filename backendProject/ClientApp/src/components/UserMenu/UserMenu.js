import React, {Component} from 'react';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.min.css';
import './usermenu.css'

class UserMenu extends React.Component{

	constructor(props) {
		super(props);
		this.state = {

		}
	}

	componentDidMount() {
	    console.log("Loaded userMenu");
	}

	render() {
		return (
			<div className="user-menu-container">
				<h4>Hello from userMenu</h4>
				<div className="btn-container">
					<Button variant="dark" onClick={this.props.handleLogin}>Login</Button>
					<Button variant="dark" onClick={this.props.handleLaunchGame}>Train Game!</Button>
					<Button variant="dark" onClick={this.props.handleRanking}>Ranking</Button>
				</div>
			</div>
		);
	}
}

export {UserMenu};