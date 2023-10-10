import React, { Component } from 'react';
import EventStreamComponent from './EventStream';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <EventStreamComponent />
      </div>
    );
  }
}
