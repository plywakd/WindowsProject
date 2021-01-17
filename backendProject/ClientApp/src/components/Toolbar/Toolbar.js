import React, {Component} from 'react';
import keyboardLogo from './keyboard.png'
import './toolbar.css'

class Toolbar extends React.Component{
	constructor(props) {
		super(props);
		this.state = {

		}
	}

	componentDidMount() {
	    console.log("Loaded toolbar");
	}

	render() {
		return (
			<div className="toolbar-container">
				<div className="toolbar-item">
					<h2>Speed up your typing!</h2>
				</div>
				<div className="toolbar-item">
					<img src = {keyboardLogo} alt="projLogo" className="logo"/>
				</div>
			</div>
		);
	}
}

export {Toolbar};