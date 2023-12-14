import { TestBed } from '@angular/core/testing';

import { MydataService } from './mydata.service';

describe('MydataService', () => {
  let service: MydataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MydataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
