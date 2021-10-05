import IPetData  from "./pet.type";
export default interface IOwnerData {
    id?: any | null,
    fullName: string,
    address:string,
    phone: string, 
    email: string,
    dogs: Array<IPetData>,    
    cats: Array<IPetData>
  }