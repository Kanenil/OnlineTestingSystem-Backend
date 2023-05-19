import {Component, OnInit} from '@angular/core';
import {ThemesService} from "./services/themes.service";
import {ModalService} from "./services/modal.service";
import {ActivatedRoute, NavigationEnd, Router} from "@angular/router";
import {filter, map} from "rxjs";
import {Title} from "@angular/platform-browser";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(
    public themesService : ThemesService,
    public modalService: ModalService,
    private router: Router,
    private route: ActivatedRoute,
    private titleService: Title
  ) {
  }

  ngOnInit() {
    this.themesService.initTheme();

    this.router.events
      .pipe(
        filter((event) => event instanceof NavigationEnd),
        map(() => {
          const child: ActivatedRoute | null = this.route.firstChild;
          let title = child && child.snapshot.data['title'];
          if (title) {
            return title;
          }
        })
      )
      .subscribe((title) => {
        if (title) {
          this.titleService.setTitle(`Smart Test - ${title}`);
        }
      });
  }
}
