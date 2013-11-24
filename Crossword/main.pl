use Encode qw(encode decode);
use utf8;
no warnings 'layer';
use Tk 800.00;
use Tk::Table;
use Tk::ApplicationNest;
require Tk::LabEntry;
require Tk::DialogBox;
require Tk::Dialog;
use Tk::Pod;
use Tk::Pod::Text;
use MLDBM "DB_File";
use locale;
use libs::Crossword;
use libs::VisualizationCrossword;
use libs::Application;
use libs::Menu;
use resources::Settings;

my $application = Application->new();
$application->run(Settings::DEFAULT_LANGUAGE);

MainLoop;