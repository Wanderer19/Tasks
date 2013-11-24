package Menu;
	use Encode qw(encode decode);
	use utf8;
	use Tk 800.00;
	use resources::Settings;
	
	sub cascade{
		my $self = shift;
		my ($main_window, $main_menu, $label, @command) = @_;
		
		my	$menu = $main_menu->cascade(
											-label => $label,  
											-tearoff => Settings::NO
										);
		
		for (my $i = 0; $i < @command - 2; $i += 3){
			$self->add_command_menu($menu, $command[$i], $command[$i + 1], $command[$i + 2]);
			$main_window->bind($main_window, "$command[$i + 2]" => $command[$i]);
		}
		
		$menu->separator();
		return $menu;
	}
	
	sub add_command_menu{
		my $self = shift;
		my ($menu, $command, $label, $accelerator) = @_;
		
		$menu->command(
						-label => $label,
						-background => Settings::BACKGROUND,
						-command => $command,
						-accelerator => $accelerator
					);
	}
	
	sub add_radiobutton{
		my $self = shift;
		my $menu = shift;
		my ($label, $command) = @_;
		
		$menu->radiobutton(
							-label    => $label,
							-command => $command,
											
						);
	}
1;