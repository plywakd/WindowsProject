import React, { Component } from 'react';
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
			game: Object,
		}
		this.handleGame = this.handleGame.bind(this);
	}

	componentDidMount() {
		console.log("SubMenu component");
	}

	handleGame = (xd) => {
		console.log(xd);
		this.setState({ game: xd });
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
		else if (this.props.isLogged === true && this.props.gameMenu === false && this.props.showRanking === false ) {
			subMenu = (
				<h2> Welcome {this.props.username} </h2>)
		}

		else if (this.props.isLogged === true && this.props.gameMenu === true && Object.keys(this.state.game).length == 0 && this.props.showRanking === false) {
			subMenu = (this.props.gameList.map((item) => <Button variant="primary" onClick={() => this.handleGame(item)} key={item.id}>{item.gameName}</Button>));
		}

		else if (this.props.isLogged === true && Object.keys(this.state.game).length != 0 && this.props.showRanking === false) {
			console.log(this.state.game);
			subMenu = (
				<MainMenu mainText={this.state.game.textToWrite.text} username={this.props.username} gameId={this.state.game.id}></ MainMenu>);
		}

		else if (this.props.isLogged === true && this.props.showRanking === true) {
			console.log(this.props.results);
			console.log(this.props.results[0]);
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
			const res = this.props.results;
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