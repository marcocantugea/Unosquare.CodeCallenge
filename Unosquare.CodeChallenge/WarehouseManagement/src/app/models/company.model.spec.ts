import { Company } from './company.model';

describe('Company', () => {
  it('should create an instance', () => {
    expect(new Company(0,'')).toBeTruthy();
  });
});
