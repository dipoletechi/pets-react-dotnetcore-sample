import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import logo from './logo.svg';
import './App.css';
import OwnerList from './components/owner-list.components';
import OwnerDetails from './components/owner-details.components';
import OwnerStats from './components/owner-stats.components';
import { useState } from 'react'

function App() {

  const [state, setState] = useState('0')
  const [selectedOwner, setOwner] = useState(0)
  const [selectedOwners, setOwners] = useState(new Array<number>())

  return (
    <div className="Container">
     {state=='0' && (<OwnerList onChange={(ownerId:number)=>{setOwner(ownerId);setState("1");}}   onStatsClick={(ownerids:Array<number>)=>{setOwners(ownerids);setState("2");}}/>)}
     {state=='1' && (<OwnerDetails selectedOwner={selectedOwner} onBack={()=>{setState("0")}}/>)}
     {state=='2' && (<OwnerStats selectedOwners={selectedOwners} onBack={()=>{setState("0")}}/>)}
    </div>
  );
}

export default App;
