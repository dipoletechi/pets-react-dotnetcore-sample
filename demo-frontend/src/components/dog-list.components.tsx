import { Component, ChangeEvent } from "react";
import FeedPet from "./feedpet.component";
import IPetData from "../type/pet.type";

type Props = {
    dogs: Array<IPetData>;
    ownerName:string;
    refresh: () => void;
};

export default class DogList extends Component<Props>{
    constructor(props: Props) {
        super(props);
    }

    componentDidMount() {
    }

    render() {
        return (   
                <div className="col-lg-12">
                    <table className="table">
                        <thead>
                            <th>Name</th>
                            <th>Level of training</th>
                            <th>Supposed High</th>
                            <th>Color</th>
                            <th>D.O.B.</th>
                            <th>Age</th>
                            <th>Notes</th>
                            <th>Feed</th>
                            <th>Action</th>
                        </thead>
                        <tbody>
                            {this.props.dogs && this.props.dogs.map((dog: IPetData, index: number) => (
                                <tr>
                                    <td>
                                        {dog.name}
                                    </td>
                                    <td>
                                        {dog.levelOfTraining}
                                    </td>
                                    <td>
                                        {dog.supposedHigh}
                                    </td>
                                    <td>
                                        {dog.color}
                                    </td>
                                    <td>
                                        {dog.dob}
                                    </td>
                                    <td>
                                        {dog.age}
                                    </td>
                                    <td>
                                        {dog.notes}
                                    </td>
                                    <td>
                                        {dog.feedings}
                                    </td>
                                    <td><FeedPet petId={dog.id} refresh={()=>{ this.props.refresh()}}/></td>
                                </tr>

                            ))}

                            {!this.props.dogs || this.props.dogs == null || this.props.dogs.length == 0 && (<tr> <td colSpan={7}>No dog assigned to {this.props.ownerName}</td></tr>)}
                        </tbody>
                    </table>
                </div>           
        );
    }
}

