import React, {Component} from 'react';
import {MainMenu} from '../MainMenu/MainMenu';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table'
import 'bootstrap/dist/css/bootstrap.min.css';
import './content.css';
import axios from 'axios';

class Content extends React.Component{

	constructor(props) {
		super(props);
		this.state = {
			isLogged : false,
			username : '',
			password : '',
			gameList : [],
			game_tmp: false,
			results : [],
		}
		this.handleChange = this.handleChange.bind(this);
		this.handleSubmit = this.handleSubmit.bind(this);
		this.handleRegister = this.handleRegister.bind(this);
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
		const backend_url = 'https://localhost:44306/Accounts/login/'
		axios.get(backend_url + this.state.username).
			then(response => {
				console.log(response.status)
				this.setState({ isLogged: response.status })
			})

	}


	handleRegister(event) {
		event.preventDefault();
		const backend_url = 'https://localhost:44306/Accounts/add/'
		axios.post(backend_url + this.state.username + "/" + this.state.password, {}).then(function (response) {
			console.log(response);
		})
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
						Login
					</Button>
					<Button variant="primary" type="submit" onClick={this.handleRegister}>
						Register
					</Button>
				</Form>);
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
		
		if (this.props.showRanking === true) {
			//TODO change, request is being sent over and over
			const backend_url = 'https://localhost:44306/Results';
			axios.get(backend_url).
				then(response => {
					console.log(response.status)
					console.log(response.data)
					this.setState({ results: response.data })
			})

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
			const res = this.state.results;
			//TODO create ranking based on results fields
			let rank = <Table responsive>
				<thead>
					<tr>
						<th>#</th>
						{Array.from({ length: 12 }).map((_, index) => (
							<th key={index}>Table heading</th>
						))}
					</tr>
				</thead>
				<tbody>
					for(var index=0; index<res.length; index++) {
						<tr>
							<th>index</th>
						</tr>
					}
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