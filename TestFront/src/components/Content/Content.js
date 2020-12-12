import React, {Component} from 'react';
import {MainMenu} from '../MainMenu/MainMenu';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.min.css';
import './content.css';

class Content extends React.Component{

	constructor(props) {
		super(props);
		this.state = {
			username : '',
			password : '',
		}
		this.handleSubmit = this.handleSubmit.bind(this);
	}

	componentDidMount() {
	    console.log("Content component");
	}
	
	
	handleSubmit(event) {
		event.preventDefault();
		const backend_url = 'localhost';
		console.log("sending request to backend : ");
		
	}

	render() {
		const isLogged = this.props.login;
		let subMenu;
		if (isLogged == false) {
			subMenu = 
				(<Form>
				  <Form.Group controlId="formBasicEmail">
					<Form.Label>Username</Form.Label>
					<Form.Control type="text" placeholder="Enter username" />
				  </Form.Group>

				  <Form.Group controlId="formBasicPassword">
					<Form.Label>Password</Form.Label>
					<Form.Control type="password" placeholder="Password" />
				  </Form.Group>
				  
				  <Button variant="primary" type="submit" onClick={this.handleSubmit}>
					Submit
				  </Button>
				</Form>)
		}
		return (
			<div className="container">
				<h2>{this.props.user}</h2>
					{subMenu}
			</div>			
		);
	}
}

export {Content};