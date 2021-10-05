import { Component } from "react";
import OwnerDataServie from "../services/owner.service";
import IOwnerStatsData from '../type/owner-stats.type';

type Props = {
    onBack: () => void;
    selectedOwners: Array<number>;
};


type State = {
    ownerStats: IOwnerStatsData
};



export default class OwnerStats extends Component<Props, State>{
    constructor(props: Props) {
        super(props);
        this.state = {
            ownerStats: {} as IOwnerStatsData
        };
    }

    componentDidMount() {
        this.getStatistics();
    }

    getStatistics() {

        OwnerDataServie.getOwnerStats(this.props.selectedOwners)
            .then(response => {
                this.setState({
                    ownerStats: response.data
                });   
            })
            .catch(e => {
                console.log(e);
            });
    }

    getOwnerList() {
        this.props.onBack();
    }

    render() {
        const { ownerStats } = this.state;
        return (
            <div className="row">
                <div className="col-lg-3">
                    <div className="card text-white bg-primary mb-3">
                        <div className="card-header">Total Owners</div>
                        <div className="card-body">                           
                            <p className="card-text">{ownerStats.totalOwners}</p>
                        </div>
                    </div>
                </div>

                <div className="col-lg-3">
                    <div className="card text-white bg-danger mb-3">
                        <div className="card-header">Total Pets</div>
                        <div className="card-body">                           
                            <p className="card-text">{ownerStats.totalPets}</p>
                        </div>
                    </div>
                </div>

                <div className="col-lg-3">
                    <div className="card text-white bg-success mb-3">
                        <div className="card-header">Average Number of Animals</div>
                        <div className="card-body">                           
                            <p className="card-text">{ownerStats.averageNumberOfAnimalsPerOwner}</p>
                        </div>
                    </div>
                </div>

                <div className="col-lg-3">
                    <div className="card text-white bg-dark mb-3">
                        <div className="card-header">Average Age</div>
                        <div className="card-body">                           
                            <p className="card-text">{ownerStats.averageAgeOfAnimals}</p>
                        </div>
                    </div>
                </div>
                <div className="col-lg-12">
                    <button type="button" onClick={() => this.getOwnerList()} className="btn btn-primary">Back</button>
                </div>
            </div>
        );
    }
}

