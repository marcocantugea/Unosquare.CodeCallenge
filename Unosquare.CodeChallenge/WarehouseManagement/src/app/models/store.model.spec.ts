import { Store } from './store.model';

describe('Store', () => {
  it('should create an instance', () => {
    expect(new Store(0,"","","")).toBeTruthy();
  });
});
