import React, {Component} from 'react';
import {MainMenu} from '../MainMenu/MainMenu';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table'
import 'bootstrap/dist/css/bootstrap.min.css';
import './content.css';

class Content extends React.Component{

	constructor(props) {
		super(props);
		this.state = {
			isLogged : false,
			username : '',
			password : '',
			gameList : [],
			game_tmp : false,
		}
		this.handleChange = this.handleChange.bind(this);
		this.handleSubmit = this.handleSubmit.bind(this);
		this.loadGame = this.loadGame.bind(this);
	}

	componentDidMount() {
		this.setState({isLogged : this.props.login})
	    console.log("Content component");
	}
	
	handleChange(event) {
		const target = event.target;
		const value = target.value;
		const name = target.name;
		this.setState({
		  [name]: value    
		});
  }
	
	handleSubmit(event) {
		event.preventDefault();
		const backend_url = 'localhost';
		console.log("sending request to backend :");
		console.log(this.state.username);
		console.log(this.state.password);
		const backend_response = true;
		this.setState({isLogged : backend_response})
	}
	
	loadGame() {
		console.log("Game!");
		this.setState({game_tmp : true});
	}


	render() {
		let subMenu;
		if (this.state.isLogged === false) {
			subMenu = 
				(<Form>
				  <Form.Group controlId="formBasicEmail">
					<Form.Label>Username</Form.Label>
					<Form.Control type="text" name="username" onChange={this.handleChange} placeholder="Enter username" />
				  </Form.Group>

				  <Form.Group controlId="formBasicPassword">
					<Form.Label>Password</Form.Label>
					<Form.Control type="password" name="password" onChange={this.handleChange} placeholder="Password" />
				  </Form.Group>
				  
				  <Button variant="primary" type="submit" onClick={this.handleSubmit}>
					Submit
				  </Button>
				</Form>)
		}
		else {
			subMenu = (
			<h2> Welcome {this.state.username} </h2>)
		}
		
		if (this.props.launchGame === true){
			const backend_url = 'localhost';
			console.log("sending request to backend :");
			const backend_response = ["intro typing", "lorem ipsum"];
			subMenu = backend_response.map((gameName) => <Button variant="primary" onClick={this.loadGame}>{gameName}</Button>);
		}
		
		if(this.props.showRanking === true){
			const backend_url = 'localhost';
			console.log("sending request to backend :");
			subMenu = <Table responsive>
						  <thead>
							<tr>
							  <th>#</th>
							  {Array.from({ length: 12 }).map((_, index) => (
								<th key={index}>Table heading</th>
							  ))}
							</tr>
						  </thead>
						  <tbody>
							<tr>
							  <td>1</td>
							  {Array.from({ length: 12 }).map((_, index) => (
								<td key={index}>Table cell {index}</td>
							  ))}
							</tr>
							<tr>
							  <td>2</td>
							  {Array.from({ length: 12 }).map((_, index) => (
								<td key={index}>Table cell {index}</td>
							  ))}
							</tr>
							<tr>
							  <td>3</td>
							  {Array.from({ length: 12 }).map((_, index) => (
								<td key={index}>Table cell {index}</td>
							  ))}
							</tr>
						  </tbody>
						</Table>
		}
		
		if(this.state.game_tmp === true){
			subMenu = <MainMenu></MainMenu>
		}
		return (
			<div className="container">
				{subMenu}	
			</div>			
		);
	}
}

export {Content};