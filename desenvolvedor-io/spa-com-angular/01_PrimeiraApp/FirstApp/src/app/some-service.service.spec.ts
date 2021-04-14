import { TestBed } from '@angular/core/testing';

import { SomeServiceService } from './some-service.service';

describe('SomeServiceService', () => {
  let service: SomeServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SomeServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
