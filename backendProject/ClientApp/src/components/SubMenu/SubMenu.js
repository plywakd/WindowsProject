﻿import React, { Component } from 'react';
import { MainMenu } from '../MainMenu/MainMenu';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table'
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import './SubMenu.css';

class SubMenu extends React.Component {

	constructor(props) {
		super(props);
		this.state = {

		}
	}

	componentDidMount() {
		console.log("SubMenu component");
	}

	render() {
		let subMenu;
		console.log(this.props);
		if (this.props.isLogged === false) {
			subMenu =
				(<Form>
					<Form.Group controlId="formBasicEmail">
						<Form.Label>Username</Form.Label>
						<Form.Control type="text" name="username" onChange={this.props.handleChange} placeholder="Enter username" />
					</Form.Group>

					<Form.Group controlId="formBasicPassword">
						<Form.Label>Password</Form.Label>
						<Form.Control type="password" name="password" onChange={this.props.handleChange} placeholder="Password" />
					</Form.Group>

					<Button variant="primary" type="submit" onClick={this.props.handleLogin}>
						Login
					</Button>
					<Button variant="primary" type="submit" onClick={this.props.handleRegister}>
						Register
					</Button>
				</Form>);
		}
		else if (this.props.isLogged === true && this.props.gameMenu===false){
			subMenu = (
				<h2> Welcome {this.props.username} </h2>)
		}

		else if (this.props.isLogged === true && this.props.gameMenu === true) {
			console.log("check games: " + this.props.gameList);
			subMenu = (this.props.gameList.map((item) => <Button variant="primary" onClick={this.props.handleGame(item.textToWrite)} key={item.id}>{item.gameName}</Button>));
		}

		else if (this.props.isLogged === true && this.props.launchGame === false && this.props.showRanking === true) {
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
			let elements = []
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
					{elements}
				</tbody>
			</Table>
		}

		if (this.state.game_tmp === true) {
			subMenu = <MainMenu></MainMenu>
		}
		return (
			<div className="user-menu-container">
				{subMenu}
			</div>
		);
	}
}

export { SubMenu };