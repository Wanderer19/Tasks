package Errors;
	use utf8;
	use locale;
	no warnings 'layer';
	use Encode qw(encode decode);
	use resources::Settings;
	
	sub show_error{
		my $self = shift;
		my ($main_window, $title, $message) = @_;
			
		$main_window->messageBox(
										-title => $title, 
										-message => $message, 
										-type => Settings::BUTTON_OKAY, 
										-icon => Settings::ERROR_ICON
									);
	}
1;