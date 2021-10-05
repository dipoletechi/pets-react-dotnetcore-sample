import { Component, ChangeEvent } from "react";
import DogList from "./dog-list.components";
import CatList from "./cat-list.components";
import OwnerDataServie from "../services/owner.service";
import IOwnerData from '../type/owner.type';

type Props = {
    onBack: () => void;
    selectedOwner:number;
};


type State = {
    owner: IOwnerData
};



export default class OwnerDetails extends Component<Props, State>{
    constructor(props: Props) {
        super(props);
        this.state = {
            owner: {} as IOwnerData     
        };    
    }

    componentDidMount() {    
        this.retrieveOwnerData();       
    }
   
    retrieveOwnerData() {
        OwnerDataServie.getOwnerInfo(this.props.selectedOwner)
            .then(response => {       
                console.log("Owner Info",response.data);         
                this.setState({
                    owner: response.data
                });               
            })
            .catch(e => {
                console.log(e);
            });
    }

    getOwnerList(){
        this.props.onBack();
    }

    render() {
        const { owner } = this.state;
        return (
            <div className="row">                
                <div className="col-lg-6">
                    <figure className="text-start">
                        <blockquote className="blockquote">
                            <p><b>Full Name:</b>{owner.fullName}</p>
                            <p><b>Phone:</b>{owner.phone}</p>
                            <p><b>Email:</b>{owner.email}</p>
                        </blockquote>
                        <figcaption className="blockquote-footer">
                            Address <cite title="Source Title">{owner.address}</cite>
                        </figcaption>
                    </figure>
                    
                </div>                        
                <DogList dogs={owner.dogs} refresh={()=>{ this.retrieveOwnerData()}} ownerName={owner.fullName}/>
                <CatList cats={owner.cats} refresh={()=>{ this.retrieveOwnerData()}} ownerName={owner.fullName}/>
                <div className="col-lg-12">
                    <button type="button"  onClick={() => this.getOwnerList()} className="btn btn-primary">Back</button>
                </div>                                   
            </div>
          );
    }
}

