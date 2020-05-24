import {
  Component,
  ViewEncapsulation,
  AfterViewInit,
  Injector,
} from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import {
  CarDto,
  CarServiceProxy,
} from "@shared/service-proxies/service-proxies";

@Component({
  templateUrl: "./car-edit.component.html",
  styleUrls: ["./car.component.less"],
  encapsulation: ViewEncapsulation.None,
})
export class CarEditComponent extends AppComponentBase
  implements AfterViewInit {
  /**
   *
   */
  constructor(injector: Injector, private carService: CarServiceProxy) {
    super(injector);

    this.carInput.id = this.getRouteParam("id");
    this.editPageState = this.getRouteData("editPageState");

    switch (this.editPageState) {
      case 'add':

        break;
      case 'edit':
        this.getInput();
        break;
      case 'view':
        this.getInput();
        break;
    }
  }

  get disabledAllInput() {
    return this.editPageState == 'view';
  }

  editPageState: string;

  saving = false;

  carInput: CarDto = new CarDto();

  getInput() {
    this.carService.cAR_ById(this.carInput.id).subscribe(response => {
      this.carInput = response;
    })
  }

  approve() {
    if (this.appSession.user.userName == this.carInput.makerId) {
      this.notify.error('Người chỉnh sửa cuối không được duyệt dữ liệu');
      return;
    }

    this.saving = true;
    this.carService.cAR_App(this.carInput.id, this.appSession.user.userName).subscribe(response => {
      this.saving = false;
      if (response["Result"] == "-1") {
        this.notify.error(response["ErrorDesc"]);
      } else {
        this.carInput.authStatus = 'A';
        this.notify.success('Duyệt thành công');
      }
    })
  }

  save() {
    if (!this.carInput.carID) {
      this.notify.error("Mã xe bắt buộc nhập");
      return;
    }
    this.saving = true;
    this.carInput.authStatus = 'U';
    this.carInput.makerId = this.appSession.user.userName;
    switch (this.editPageState) {
      case 'add':
        this.carService.cAR_Ins(this.carInput).subscribe((response) => {
          if (response["Result"] == "-1") {
            this.notify.error(response["ErrorDesc"]);
          } else {
            this.saving = false;
            this.notify.info(this.l("SavedSuccessfully"));
          }
        });
        break;
      case 'edit':
        this.carService.cAR_Upd(this.carInput).subscribe((response) => {
          if (response["Result"] == "-1") {
            this.notify.error(response["ErrorDesc"]);
          } else {
            this.saving = false;
            this.notify.info(this.l("SavedSuccessfully"));
          }
        });
        break;
      case 'view':
        break;
    }


  }

  ngAfterViewInit(): void { }
}
