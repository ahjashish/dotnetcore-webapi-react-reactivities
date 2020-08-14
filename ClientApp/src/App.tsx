import React from 'react';

import { Header, Icon, List } from "semantic-ui-react";

import axios from "axios";
import './App.css';

class App extends React.Component {

  state = {
    values: []
  }

  componentDidMount() {
    axios.get("https://localhost:5001/api/values")
      .then(resp => {
        this.setState({
          values: resp.data
        })
      })
  }

  render() {
    return (
      <div className="App">
        <Header as='h2'>
          <Icon name='users' />
          <Header.Content>Reactivites</Header.Content>
        </Header>
        <List>
          {
            this.state.values.map((value: any) => (
              <List.Item key={value.id}>{value.name}</List.Item>
            ))
          }
        </List>
      </div>
    );
  }
}

export default App;
