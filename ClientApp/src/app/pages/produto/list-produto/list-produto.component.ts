import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProdutoService } from '../produto.service';

@Component({
  selector: 'app-list-produto',
  templateUrl: './list-produto.component.html',
  styleUrls: ['./list-produto.component.css']
})
export class ListProdutoComponent implements OnInit {
  opemModal = false;
  titulo: '';
  listProduto: Array<any>;
  filtro: FormGroup;
  loading = false;
  idProduto = '';
  constructor(private service: ProdutoService,
    private activeRoute: ActivatedRoute,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.filtro = this.fb.group({
      nome: [''],
      valor: [''],
    });
    this.search();
    this.titulo = this.activeRoute.snapshot.data.breadcrumb;
  }
  search() {
    this.loading = true;
    this.service.getFilter(this.filtro.value, (el) => {
      if (el && el.object) {
        this.listProduto = el.object;
      } else {
        this.listProduto = [];
        this.toastr.warning("Nenhum produto encotrado!")
      }
      this.loading = false;
    }), (error) => {
      this.loading = false;
      this.toastr.error('Error interno!');
    }
  }
  modal(id) {
    this.idProduto = id;
    this.opemModal = true;
  }
  excluir(id) {
    this.service.httpDelete(Number(id)).subscribe({
      next: (response) => this.deleteProductSuccess(response),
      error: () => this.deleteProductError()
    }).add(() => {
      this.resetValues();
    });
  }
  resetValues() {
    this.loading = false;
    this.idProduto = '';
    this.opemModal = false;
  }
  deleteProductSuccess(el) {
    if (el && el.status) {
      this.search();
      this.toastr.success(el.message)
    } else {
      this.deleteProductError(el.message);
    }
  }
  deleteProductError(msg?) {
    this.toastr.error(msg || 'Error interno!');
  }

  fecharModal(opem) {
    this.idProduto = '';
    this.opemModal = opem;
  }
}
