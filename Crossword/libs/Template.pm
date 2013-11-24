package Template;	
	
	sub new{
		my $class = shift;
		my ($x1, $y1, $x2, $y2) = @_;
		
		return undef unless (($x1 == $x2 && $y2 > $y1) or ($y1 == $y2 && $x2 > $x1));
		
		my $self = bless { 
							x1 => $x1,
							y1 => $y1,
							x2 => $x2,
							y2 => $y2,
							direction => $y1 == $y2 ? "d" : "r"
						}, $class;
	
		return $self;
	}
	
	sub overlap{
		my $self = shift;
		my $template = shift;
		
		if ($self->{direction} eq $template->{direction}){					
			for my $i ($self->get_layout()){
				for my $j ($template->get_layout()){
					return 1 if ($$i[0] == $$j[0] && $$i[1] == $$j[1]);
				}
			}
		}
		
		return 0;
	}
	
	sub get_layout{
		my $self = shift;
		
		my $direction_row = 0;
		my $direction_column = 0;
		my $length = 0;
		
		if ($self->{direction} eq "d"){
			 $direction_row = 1;
			 $length = $self->{x2} - $self->{x1};
		}
		else{
			 $direction_column = 1;
			 $length = $self->{y2} - $self->{y1}; 
		}
		
		my @layout;
		for my $i (0 .. $length){
			push @layout, [$self->{x1} + $direction_row * $i, $self->{y1} + $direction_column * $i];
		}
		
		return @layout;
	}
	
	sub equals{
		my $self = shift;
		my $template = shift;
		
		return ($self->{x1} == $template->{x1} && $self->{x2} == $template->{x2} && $self->{y1} == $template->{y1} && $self->{y2} == $template->{y2});
	}
	
	sub contains{
		my $self = shift;
		my ($x, $y) = @_;
		
		return 0 unless (($x >= $self->{x1} && $x <= $self->{x2}) || ($x >= $self->{x2} && $x <= $self->{x1}));
		return 0 unless (($x - $self->{x1}) * ($self->{y2} - $self->{y1}) - ($y - $self->{y1}) * ($self->{x2} - $self->{x1}) == 0);
		
		return 1;
	}
1;