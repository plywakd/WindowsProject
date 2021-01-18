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
			resultHeader: Object,
		}
		this.handleGame = this.handleGame.bind(this);
		this.handleParam = this.handleParam.bind(this);
	}

	componentDidMount() {
		console.log("SubMenu component");
	}

	handleGame = (xd) => {
		this.setState({ game: xd });
	}

	handleParam = (toRecognize) => {
		console.log(toRecognize);
		if (typeof (toRecognize) === 'string') {
			let date = new Date(toRecognize);
			return date.toString()
		}
		if (typeof (toRecognize) === 'object') {
			if (Object.keys(toRecognize).includes("username")) {
				return toRecognize.username
			}
			else if (Object.keys(toRecognize).includes("gameName")) {
				return toRecognize.gameName
            }
        }
		return ""
    }

	render() {
		let subMenu;
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
			subMenu = (
				<MainMenu mainText={this.state.game.textToWrite.text} username={this.props.username} gameId={this.state.game.id} textId={this.state.game.textToWrite.id}></ MainMenu>);
		}

		else if (this.props.isLogged === true && this.props.showRanking === true) {
			let headers;
			let header;
			let res;
			if (Object.keys(this.props.results) != 0) {
				res = this.props.results;
				headers = Object.values(res)[0];
				if (headers) {
					header = Object.keys(headers);
					if (header) {
						subMenu = <Table responsive>
							<thead>
								<tr>
									{header.map((k, i) => <th key={i}>{k}</th>)}
								</tr>
							</thead>
							<tbody>
								{
									res.map((r,i) => (
										<tr key={i}>{
											//Object.values(r).map((resval, j) => <td key={j}>{(Object.keys(resval).length !=0) ? this.handleParam(resval) : resval.toString()}</td>)
											Object.values(r).map((resval, j) => <td key={j}>{resval.toString()}</td>)
                                        }
										</tr>
									))
                                }
							</tbody>
						</Table>
                    }
                }
            }
		}
		return (
			<div className="user-menu-container">
				{subMenu}
			</div>
		);
	}
}

export { SubMenu };