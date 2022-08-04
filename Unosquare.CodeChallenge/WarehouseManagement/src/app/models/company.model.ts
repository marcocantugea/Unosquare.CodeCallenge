export class Company {
  public id: number;
  public name: string;

  constructor(Id: number , Name: string) {
    this.id = Id;
    this.name = Name;
  }

  getName(): string { return this.name }
  getId(): number { return this.id }
  setId(id: number) { this.id = id }
  setName(name: string) { this.name = name }
}
