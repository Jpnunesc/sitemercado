import { TestBed } from '@angular/core/testing';

import { ServicoPadraoService } from './servico-padrao.service';

describe('ServicoPadraoService', () => {
  let service: ServicoPadraoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicoPadraoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
