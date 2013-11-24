package Geometry;
	use Class::Struct;
	use libs::Template;
	use resources::Settings;
	
	struct Geometry =>{
		rows => '$',
		columns => '$',
		templates_words => '@',
	};
	
	sub save_template_word{
		my $self = shift;
	
		my ($x1, $y1, $x2, $y2) = @_;
		my $new_template = new Template($x1, $y1, $x2, $y2);
		if ($self->check_template($new_template)){			
			push @{$self->templates_words}, $new_template;
			return 1;
		}
		
		return 0;
	}
		
	sub check_template{
		my $self = shift;
		my $template = shift;
		
		return 0 unless ($template);
		return 1 unless(@{$self->templates_words});
		
		for (@{$self->templates_words}){
			return 0 if ($template->overlap($_));
		}
		
		return 1;
	}
	
	sub delete_word{
		my $self = shift;
		
		my ($x1, $y1, $x2, $y2) = @_;
		
		for my $template (@{$self->templates_words}){
			if ($template->contains($x1, $y1 ) && $template->contains($x2, $y2 )){
				@{$self->templates_words} = grep { !$_->equals($template) } @{$self->templates_words};
				return [$template->{x1}, $template->{y1}, $template->{x2}, $template->{y2}];
			}
		}
		return undef;
	}
	
	sub is_geometry_undefined{
		my $self = shift;
		
		return 1 unless ($self->templates_words->[0]);
		return 0;
	}
	
	sub clear{
		my $self = shift;

		@{$self->templates_words} = ();
	}
	
	sub get_matrix_geometry{
		my $self = shift;
		
		my @geometry;
		for my $template (@{$self->templates_words}){
			$geometry[$$_[0]][$$_[1]] = 1 for ($template->get_layout());
		}

		return @geometry;
	}
1;