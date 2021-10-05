import { Component, ChangeEvent } from "react";
import FeedPet from "./feedpet.component";
import IPetData from "../type/pet.type";

type Props = {
    cats: Array<IPetData>;
    ownerName: string;
    refresh: () => void;
};

export default class CatList extends Component<Props>{
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
                        <th>Catching Mouses</th>
                        <th>Color</th>
                        <th>D.O.B.</th>
                        <th>Age</th>
                        <th>Notes</th>
                        <th>Feed</th>
                        <th>Action</th>
                    </thead>
                    <tbody>
                        {this.props.cats && this.props.cats.map((cat: IPetData, index: number) => (
                            <tr>
                                <td>
                                    {cat.name}
                                </td>
                                <td>
                                    {cat.catchingMouses}
                                </td>
                                <td>
                                    {cat.color}
                                </td>
                                <td>
                                    {cat.dob}
                                </td>
                                <td>
                                    {cat.age}
                                </td>
                                <td>
                                    {cat.notes}
                                </td>
                                <td>
                                        {cat.feedings}
                                </td>
                                    <td><FeedPet petId={cat.id} refresh={()=>{ this.props.refresh()}}/></td>
                            </tr>

                        ))}

                        {!this.props.cats || this.props.cats == null || this.props.cats.length == 0 && (<tr> <td colSpan={7}>No cat assigned to {this.props.ownerName}</td></tr>)}
                    </tbody>
                </table>
            </div>
        );
    }
}

