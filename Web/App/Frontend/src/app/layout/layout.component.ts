import { Component } from "@angular/core";
import { NavigationEnd, Router, RouterEvent } from "@angular/router";
import { filter } from "rxjs/operators";
import { AuthenticationService } from "../services/authentication.service";

@Component({ selector: "app-layout", templateUrl: "./layout.component.html" })
export class LayoutComponent {
    isNavVisible: boolean = false;

    constructor(
        private readonly authenticationService: AuthenticationService,
        private readonly router: Router) {
        this.SetIsNavVisible();
    }

    private SetIsNavVisible() {
        this.router.events
            .pipe(filter((event: RouterEvent) => event instanceof NavigationEnd))
            .subscribe((event: NavigationEnd) => {
                this.isNavVisible = this.authenticationService.isAuthenticated() && !event.url.endsWith("login");
            });
    }
}
