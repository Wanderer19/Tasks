use Tk;

my $mw = MainWindow->new();
$canvas = $mw->Canvas( );
$canvas->CanvasBind("<Button-1>", sub { print "bind!\n"; });
$canvas = $mw->Scrolled("Canvas");
$real_canvas = $canvas->Subwidget("canvas");
$real_canvas->CanvasBind("<Button-1>", sub { print "bind!\n" });
$c = $mw->Scrolled("Canvas")->pack( );
$canvas = $c->Subwidget("canvas");
$canvas->CanvasBind("<Button-1>", [ \&print_xy, Ev('x'), Ev('y') ]);
sub print_xy {
  my ($canv, $x, $y) = @_;
  print "(x,y) = ", $canv->canvasx($x), ", ", $canv->canvasy($y), "\n";
}
#$id = $canvas->createLine(40,40, 42,42, -width => 5);           # creates one line
#$canvas->createOval(0,0, 10, 10, -tags => "oval");
$id = $canvas->createPolygon(223,86,  224,143, 295, 154,304,87, -fill => "blue");
#$id = $canvas->createLine(40,40, 40,40, -width => 100); 

MainLoop;