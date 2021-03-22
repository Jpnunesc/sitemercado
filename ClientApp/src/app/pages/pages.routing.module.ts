import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from './usuario/login/login.component';
import { AuthGuard } from '../core/shared/auth/auth.guard';
import { ListProdutoComponent } from './produto/list-produto/list-produto.component';
import { FormProdutoComponent } from './produto/form-produto/form-produto.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', component: LoginComponent },
  {
    path: 'produto',
    canActivate: [AuthGuard],
    data: {
      titulo: 'Cadastrar',
      breadcrumb: "Produto"
    },
    children: [
      {
        path: 'listar',
        component: ListProdutoComponent,
        canActivate: [AuthGuard],
        data: {
          titulo: 'Listar',
          breadcrumb: "Produtos"
        },
      },
      {
        path: '',
        component: ListProdutoComponent,
        canActivate: [AuthGuard],
        data: {
          titulo: 'Listar',
          breadcrumb: "Produtos"
        },
      },
      {
        path: 'alterar/:id',
        component: FormProdutoComponent,
        canActivate: [AuthGuard],
        data: {
          titulo: 'Alterar',
          breadcrumb: "Alterar Produto"
        },
      },
      {
        path: 'detalhar/:id',
        component: FormProdutoComponent,
        canActivate: [AuthGuard],
        data: {
          titulo: 'Detalhar',
          breadcrumb: "Detalhes do Produto"
        },
      },
      {
        path: 'incluir',
        component: FormProdutoComponent,
        canActivate: [AuthGuard],
        data: {
          titulo: 'Cadastrar',
          breadcrumb: "Cadastrar Produto"
        },
      },
    ]
  },
  { path: '**', redirectTo: '' }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations: []
})
export class PagesRoutingModule { }
