import React, {Component} from 'react';
import {UserMenu} from './components/UserMenu/UserMenu';
import {Content} from './components/Content/Content';
import {MainMenu} from './components/MainMenu/MainMenu';

class App extends Component{

	constructor(props) {
		super(props);
		this.state = {
            username : "",
            password : "",
            isLogged : false,
		}
	}
	
	componentDidMount() {
	    console.log("Loaded App js");
	}
	
	render() {
		return (
			<React.Fragment>
				<div>
					<h3>"Hello"</h3>
					<UserMenu></UserMenu>
					<MainMenu></MainMenu>
				</div>
			</React.Fragment>
		);
	}
}

export default App;