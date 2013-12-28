package Country;
	sub New{
		my $class = shift;
		my @coordinates = @_;
		
		my $self = {};
		$self->{coordinates} = \@coordinates;
		
		return bless $self, $class;
	}

	sub GetCoordinates{
		my $self = shift;
		
		my @coordinates;
		for (@{$self->{coordinates}}){
			push @coordinates, @$_;
		}
		
		return @coordinates;
	}
	
	sub Overlap{
		my $self = shift;
		my ($line, $country) = @_;
	
		my $x1 = $self->{coordinates}->[$$line[0]]->[0];
		my $x2 = $self->{coordinates}->[$$line[1]]->[0];
		my $y1 = $self->{coordinates}->[$$line[0]]->[1];
		my $y2 = $self->{coordinates}->[$$line[1]]->[1];
		
		my $count = 0;
		for (@{$country->{coordinates}}){
			my $x = $$_[0];
			my $y = $$_[1];
			
			$count++  if ((($x * ($y1 * $x2 - $y2 * $x2) + $x2 * ($x1 * $y2 - $y1 * $x2)) / ($x2 * ($x1 - $x2))) == $y);
		}
			
		return $count > 1;
	}
	
	sub GetLines{
		my $self = shift;
		
		my @lines;
		for (my $i = 0; $i < scalar @{$self->{coordinates}} - 1; ++$i){
			push @lines, [$i, $i + 1];
		}
		
		push @lines, [scalar @{$self->{coordinates}} - 1, 0];

		return @lines;
	}
	
1;