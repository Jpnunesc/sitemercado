import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { debounceTime, take } from 'rxjs/operators';
import { ServicoPadraoService } from 'src/app/core/servico/servico-padrao.service';
import { environment } from 'src/environments/environment.prod';


const url = `${environment.URL}/Produto`;

@Injectable({
  providedIn: 'root'
})
export class ProdutoService extends ServicoPadraoService<any>  {

  constructor(
    protected http: HttpClient) {
    super(http, url, true)
  }
  Incluir(registro: any, callback?) {
     const formData = new FormData();
    // // formData.append('file', registro.imagem);
    // formData.set('produto', registro);
  
    //  registro.arquivo = registro.imagem
      // registro.imagem = '';
    formData.append('produto', JSON.stringify(registro));
    this.http.post<any>(this.url, formData)
      .subscribe((resp: any) => {
        callback(resp);
      });
  }
  getFilter(filtro, callback?) {
    let params = new HttpParams()
      .set("nome", filtro.nome)
      .set("valor", filtro.valor);

    this.http.get(this.url, { params })
      .pipe(debounceTime(800))
      .subscribe((data: any) => {
        callback(data);
      });
  }

}
