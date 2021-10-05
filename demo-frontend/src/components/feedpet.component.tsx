import { Component, ChangeEvent } from "react";
import PetDataServie from "../services/pet.service";

type Props = {
    petId: number;
    refresh: () => void;      
};

export default class FeedPet extends Component<Props>{
    constructor(props: Props) {
        super(props);
    }

    componentDidMount() {
    }

    feedPet() {
        console.log(this.props.petId);
        PetDataServie.feed(this.props.petId)
            .then(response => {                      
                this.props.refresh();                                   
            })
            .catch(e => {
                console.log(e);
            });
    }

    render() {
        return (   
                <div>
                    <button type="button"  onClick={() => this.feedPet()} className="btn btn-primary">Feeding</button>
                </div>           
        );
    }
}

