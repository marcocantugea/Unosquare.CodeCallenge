import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Company } from '../models/company.model';
import { ICompany } from '../interfaces/ICompany';


const host = 'https://localhost:7032/'
const apiResouce = 'api/company';
const apiResoucePlural = 'api/companies';
@Injectable({
  providedIn: 'root'
})
export class CompaniesService {

  private listOfCompanies: Observable<ICompany> | null = null;
  public listOfCompaniesBehavior = new BehaviorSubject<ICompany[]>([]);
  listOfCOmpaniesBehavior$ = this.listOfCompanies;

  
  constructor(private http: HttpClient) { }

  getAllCompanies(): Observable<ICompany[]> {
    return this.http.get<ICompany[]>(host + apiResoucePlural);
  }

  getCompany(id: string) : Observable<ICompany> {
    return this.http.get<ICompany>(host + apiResouce + "/" + id);
  }

  getCompanyByName(name: string): Observable<ICompany> {
    return this.http.get<ICompany>(host + apiResouce + "/search?name=" + name);
  }

  addCompany(name: string): Observable<any>  {
    let item = {
      Name:name 
    }
    const headers = { 'Content-type': 'application/json' };
    return this.http.post(host + apiResouce, JSON.stringify(item), { headers });
  }

  deleteCompany(idCompany: string): Observable<any> {
    let item = {
      Id:idCompany
    }
    return this.http.delete(host + apiResouce+"/"+idCompany)
  }

  updateCompanyInfo(company: Company) {
    return this.http.put(host + apiResouce, company);
  }
}
