import { AngularTestTemplatePage } from './app.po';

describe('AngularTest App', function() {
  let page: AngularTestTemplatePage;

  beforeEach(() => {
    page = new AngularTestTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
