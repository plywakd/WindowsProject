import React, {Component} from 'react';
import {MainMenu} from '../MainMenu/MainMenu';
import './content.css';

class Content extends React.Component{

	constructor(props) {
		super(props);
		this.state = {

		}
	}

	componentDidMount() {
	    console.log("Content component");
	}

	render() {
		return (
			<div className="container">
				<h2>Hello from content</h2>
			</div>			
		);
	}
}

export {Content};