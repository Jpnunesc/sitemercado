import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProdutoService } from '../produto.service';

@Component({
  selector: 'app-form-produto',
  templateUrl: './form-produto.component.html',
  styleUrls: ['./form-produto.component.css']
})
export class FormProdutoComponent implements OnInit {

  formulario: FormGroup;
  disabled = false;
  titulo = '';
  tituloPage = '';
  codigo = false;
  file: File;
  imageUrl: string | ArrayBuffer = "";
  fileName: string = "No file selected";
  loading = false;

  constructor(private fb: FormBuilder,
    private activeRoute: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router,
    private service: ProdutoService) { }

  ngOnInit(): void {
    const id = this.activeRoute.snapshot.params.id;
    this.tituloPage = this.activeRoute.snapshot.data.breadcrumb;
    this.titulo = this.activeRoute.snapshot.data.titulo;
    if (id) {
      if (this.titulo == 'Detalhar') {
        this.disabled = true;
      }
      this.fillForm(id);
    }
    this.buildForm();
  }
  buildForm() {
    this.formulario = this.fb.group({
      id: [{ value: '', disabled: this.disabled }],
      nome: [{ value: '', disabled: this.disabled }, [Validators.required]],
      imagem: [''],
      valor: [{ value: '', disabled: this.disabled }, [Validators.required]],
    });
  }
  save() {
    if (!this.formulario.invalid) {
      this.loading = true;
      // this.formulario.get('imagem').setValue(this.file);
      const obj = this.formulario.value
      if (this.titulo == 'Alterar') {
        obj.id = String(obj.id);
        this.service.httpPut(obj).subscribe(el => {
          this.loading = false;
          if (el.status) {
            this.toastr.success(el.message);
          } else {
            this.toastr.error(el.message);
          }
        }), (error) => {
          this.loading = false;
          this.toastr.error('Error interno!');
        }
      } else {
        this.service.Incluir(obj, el => {
          this.loading = false;
          if (el.status) {
            this.formulario.reset();
            this.apagarImg();
            this.toastr.success(el.message);
          } else {
            this.toastr.error(el.message);
          }
        }), (error) => {
          this.loading = false;
          this.toastr.error('Error interno!');
        }
      }
    }
  }

  fillForm(id) {
    this.loading = true;
    this.codigo = true;
    this.service.httpGetId(Number(id)).subscribe(el => {
      this.loading = false;
      if (el && el.status) {
        this.imageUrl = el.object.imagem;
        this.formulario.patchValue(el.object);
        this.file = this.formulario.get('imagem').value;
      }
    }), (error) => {
      this.loading = false;
      this.toastr.error('Error interno!');
    }
  }
  onChange = (e) => {
    const file = e;
    this.getBase64(file)
      .then((result) => {
        this.formulario.get('imagem').setValue(result);
      })
      .catch(e => console.log(e));
    this.fileName = file.name;
    this.file = file;
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = event => {
      this.imageUrl = reader.result;
    };

  }
  getBase64 = (file) => new Promise(function (resolve, reject) {
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result)
    reader.onerror = (error) => reject('Error');
  })

  apagarImg() {
    const reader = new FileReader();
    reader.readAsDataURL(this.file);
    reader.onload = event => {
      this.imageUrl = '';
    };
    this.fileName = '';
    this.file = null;
  }
  voltar() {
    this.router.navigateByUrl("produto/listar");
  }
}