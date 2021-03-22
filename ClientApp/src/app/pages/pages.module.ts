import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages.routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FieldErrorsComponent } from '../core/shared/field-errors/field-errors.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { LoginComponent } from './usuario/login/login.component';
import { FormProdutoComponent } from './produto/form-produto/form-produto.component';
import { ListProdutoComponent } from './produto/list-produto/list-produto.component';
import { CurrencyMaskConfig, CurrencyMaskModule, CURRENCY_MASK_CONFIG } from 'ng2-currency-mask';
import { LoadingComponent } from '../core/shared/loading/loading/loading.component';
import { ModalComponent } from '../core/shared/modal/modal/modal.component';

export const CustomCurrencyMaskConfig: CurrencyMaskConfig = {
  align: "right",
  allowNegative: true,
  decimal: ",",
  precision: 2,
  prefix: "R$ ",
  suffix: "",
  thousands: "."
};
@NgModule({
  imports: [
    PagesRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    CurrencyMaskModule
  ],
  declarations: [
    FieldErrorsComponent,
    UsuarioComponent,
    LoginComponent,
    FormProdutoComponent,
    ListProdutoComponent,
    LoadingComponent,
    ModalComponent,
    
  ],
  providers: [
    { provide: CURRENCY_MASK_CONFIG, useValue: CustomCurrencyMaskConfig }
  ]
})
export class PagesModule { }
