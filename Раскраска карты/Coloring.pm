package Coloring;
	sub New{
		my $class = shift;
		my $polygons = shift;
		
		my $self = {};
		$self->{coloring} = {};
			
		$self->{polygons} = $polygons;
		$self->{size} = scalar @$polygons - 1;
		
		my @colors = (0 .. scalar @$polygons - 1);
		$self->{colors} = \@colors;
		
		return bless $self, $class;
	}
	
	sub Colorize{
		my $self = shift;
		
		$self->{coloring}->{0} = 0;
		$self->AssignColor(1);
	}
	
	sub AssignColor{
		my $self = shift;
		my $index = shift;
	
		if ($index > $self->{size}){
			return 0;
		}
		else{
			my $flag = 0;
			for my $color (values %{$self->{coloring}}){
				my $flag = 1;
				for (keys %{$self->{coloring}}){
					my $neib = $self->{polygons}->[$index]->[$_];
					if ($neib == 1 && $self->{coloring}->{$_} == $color){
						$flag = 0;
						last;
					}
					
			
				}
				
				if ($flag){
					$self->{coloring}->{$index} = $color;
					$self->AssignColor($index + 1);
				}
			}
			
			if (scalar values %{$self->{coloring}} < scalar @{$self->{colors}}){
				$self->{coloring}->{$index} = $self->MaxColor();
				$self->AssignColor($index + 1);
			}
			
		}
	}
	
	sub MaxColor{
		my $self = shift;
		
		my $color = 0;
		for (values %{$self->{coloring}}){
			if ($_ > $color){
				$color = $_;
			}
		}
		
		return $color + 1;
	}
1;