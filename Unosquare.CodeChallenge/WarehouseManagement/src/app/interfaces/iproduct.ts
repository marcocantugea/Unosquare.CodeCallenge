import { ICompany } from "./ICompany";
import { IStore } from "./istore";

export interface IProduct {
  id: number;
  name: string;
  description: string;
  ageRestriction: number;
  company: ICompany;
  price: number;
  imageIurl: string,
  companyId:number,
  storeid: number,
  store: IStore;
  warehouseInfo: [];
}
