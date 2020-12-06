import React, {Component} from 'react';
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
			</div>
		);
	}
}

export {UserMenu};