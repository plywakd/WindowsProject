import React, {Component} from 'react';

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
			<Content/>
		);
	}
}

export {Content};