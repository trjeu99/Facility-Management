import {
  Component,
  ViewEncapsulation,
  AfterViewInit,
  Injector,
  OnInit,
} from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import {
  CarDto,
  CarServiceProxy,
} from "@shared/service-proxies/service-proxies";
import * as moment from "moment";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Component({
  selector: 'app-car-proposal',
  templateUrl: './car-proposal.component.html',
  styleUrls: ['./car-proposal.component.css']
})
export class CarProposalComponent extends AppComponentBase
  implements AfterViewInit, OnInit {

  listModalCar = ['Mercedesz', 'BMW', 'Toyota', 'Bugati', 'Huyndai', 'Ford'];
  listTypeCar = ['Sedal', 'SUV', 'Sports', 'Truck']

  test = "";
  nameCar = "";
  modelCar = "";
  codeCar = "";
  priceCar = "";
  typeCar = "";
  brandCar = "";
  colorCar = "";

  dkDate: Date;
  dkPrice: number;
  dbDate: Date = new Date();
  dbPrice: number;
  bhDate: Date = new Date();
  bhPrice: number;
  bhtnDate: Date = new Date();
  bhtnPrice: number;
  blCarCheck: boolean; // boolean có hoặc không
  indexOfTypeCar: number;
  submitted = false;

  carForm: FormGroup;
  constructor(injector: Injector, private carService: CarServiceProxy, private httpClient: HttpClient, private formBuilder: FormBuilder) {
    super(injector);

  }

  ngOnInit() {
    this.carForm = this.formBuilder.group({
      modelCar: ['', Validators.required],
      nameCar: ['', Validators.required],
      codeCar: ['', Validators.required],
      priceCar: ['', Validators.required],
      typeCar: ['', Validators.required],
      brandCar: ['', Validators.required],
      colorCar: ['', Validators.required],
      dkDate: ['', Validators.required],
      dkPrice: [0, Validators.required],
      dbPrice: [0, Validators.required],
      dbDate: ['', Validators.required],
      bhDate: ['', Validators.required],
      bhPrice: [0, Validators.required],
      bhtnDate: [''],
      bhtnPrice: [0],
      blCarCheck: [false],
    });

    this.resetForm();
  }

  get f() { return this.carForm.controls; }

  ngAfterViewInit(): void {

  }

  checBHTN() {
    return this.carForm.value.blCarCheck;
  }

  resetForm() {
    this.carForm.reset();
    this.carForm.controls['blCarCheck'].setValue(false);
  }

  add() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.carForm.invalid) {
      return;
    }

    const url = `http://localhost:5000/api/Car/Xe_Ins`;

    const body = {
      "ma": 0,
      "xe_Ma": this.carForm.value.codeCar,
      "xe_Ten": this.carForm.value.nameCar,
      "xe_LoaiXe": this.indexOfTypeCar,
      "xe_Gia": +this.carForm.value.priceCar,
      "xe_Mau": this.carForm.value.codeCar,
      "xe_NgayTao": new Date(),
      "xe_NgayApprove": new Date(),
      "xe_TrangThai": 0,
      "xe_NguoiTao": this.appSession.user.userName, // current user name
      "xe_PhieuDKDuongBo": this.carForm.value.dbPrice,
      "xe_PhieuDangKiem": this.carForm.value.dkPrice,
      "xe_BaoHiem": this.carForm.value.bhPrice,
      "xe_BaoHiemTuNguyen": this.carForm.value.bhtnPrice || 0,
    }

    let headers = new HttpHeaders();

    headers = headers.append("content-type", "application/json");

    this.httpClient.post(url, body, { headers }).subscribe(
      data => {
        if (data['result']['Result'] !== "-1") {

          this.notify.success("Thêm đề xuất xe thành công!", "SUCCESS")
          this.resetForm();
          this.submitted = false;
        }
        else this.notify.error("Thêm đề xuất xe không thành công. " + data['result']['ErrorDesc'], "ERROR");

      },
      err => {
        console.log(err);
      }
    );

  }

  getIndexType(event) {
    this.indexOfTypeCar = event.target.selectedIndex - 1;
  }

}
