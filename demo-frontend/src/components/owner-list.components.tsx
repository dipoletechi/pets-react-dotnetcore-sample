import { Component, ChangeEvent } from "react";
import OwnerDataServie from "../services/owner.service";
import { Link } from "react-router-dom";
import IOwnerData from '../type/owner.type';

type Props = {
    onChange: (ownerId:number) => void;
    onStatsClick:(ownerIds:Array<number>) => void;
};

type State = {
    owners: Array<IOwnerData>,
    selectedOwners:Array<IOwnerData>   
};



export default class OwnerList extends Component<Props, State>{
    
    constructor(props: Props) {
        super(props);      
        this.state = {
            owners: [],
            selectedOwners:[]            
        };
    }

    componentDidMount() {
        this.retrieveOwners();     
    }

    retrieveOwners() {
        OwnerDataServie.getAll()
            .then(response => {                
                this.setState({
                    owners: response.data
                });               
            })
            .catch(e => {
                console.log(e);
            });
    }

    getOwnerDetail(owner:IOwnerData,index:number){      
        this.props.onChange(owner.id);
    }

    selectionChange(e:any, selectedOwner:IOwnerData){      
        var selectedOwners = [];
        for(var i=0;i<this.state.selectedOwners.length;i++){
        
            if(e.target.checked == false && this.state.selectedOwners[i].id == selectedOwner.id) {
                continue;
            } else {
                selectedOwners.push(this.state.selectedOwners[i]);
            }
           
        }
      
        if(e.target.checked == true) {
            selectedOwners.push(selectedOwner);
        }

        this.setState({
            selectedOwners: selectedOwners
        }); 
    }

    getStatistics() {
        // Here, we invoke the callback with the new value
            console.log(this.state.selectedOwners);
            var ownerIds =[];

             for(var i=0;i<this.state.selectedOwners.length;i++) {
                ownerIds.push(this.state.selectedOwners[i].id);
             }

             if(ownerIds.length == 0) {
                 alert("Please select atleast one owner");
                 return;
             }

            this.props.onStatsClick(ownerIds);            
    }

    render() {
        const { owners } = this.state;
        return (
            <div className="row">
              <div className="col-lg-12">               
                <table className="table" id="ownertable">
                    <tr><th>Action</th><th>Owner Name</th><th>Phone</th><th>Address</th></tr>
                    {owners &&
                        owners.map((owner: IOwnerData, index: number) => (
                            <tr >
                                <td>
                                    <input onChange={(e)=>this.selectionChange(e, owner)}  type="checkbox" value=""/>
                                </td>
                                <td style={{cursor:"pointer"}} onClick={() => this.getOwnerDetail(owner, index)}>
                                    {owner.fullName}
                                </td>
                                <td style={{cursor:"pointer"}} onClick={() => this.getOwnerDetail(owner, index)}>
                                    {owner.phone}
                                </td>
                                <td style={{cursor:"pointer"}} onClick={() => this.getOwnerDetail(owner, index)}>
                                    {owner.address}
                                </td>
                            </tr>
                        
                        ))}
                    </table>   
              </div>
              <div className="col-lg-12">
                    <button type="button"  onClick={() => this.getStatistics()} className="btn btn-primary">Show Statstics</button>
                </div>                
            </div>
          );
    }
}

