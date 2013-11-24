package Crossword;
use libs::CrosswordTemplate;

	sub new{
		my $class = shift;
		my ($geometry, $words) = @_;
		
		my $self = bless { 
							rows => $geometry->rows,
							columns => $geometry->columns
						}, $class;
			
		$self->set_templates_words($geometry->templates_words);
		$self->set_all_lengths();
		$self->set_sorted_words($words);
	
		return $self;
	}
	
	sub set_templates_words{
		my $self = shift;
		my $templates = shift;
		
		for (@$templates){
			push @{$self->{templates_words}}, new CrosswordTemplate($_->{x1}, $_->{y1}, $_->{x2}, $_->{y2});
		}
	}
	
	sub get_geometry{
		my $self = shift;
		my (@work, @geometry);
		
		for my $template (@{$self->{templates_words}}){
			$work[$$_[0]][$$_[1]] = 1 for ($template->get_layout());
		}
		
		for my $i (0 .. $self->{rows} - 1){
			for my $j (0 .. $self->{columns} - 1){
				my %cell;
				
				$cell{"mark"} = 0;
				$cell{"mark"} = 1 if (defined($work[$i][$j]));
				
				$cell{"letter"} = "";
				$cell{"amount"} = 0;
				$geometry[$i][$j] = \%cell;
			}
		}
		
		$self->{geometry} = \@geometry;
	}
		
	sub set_all_lengths{
		my $self = shift;
		
		for  (@{$self->{templates_words}}){
			push @{$self->{all_lengths}}, $_->get_length();
		}
	}
	
	sub set_sorted_words{
		my $self = shift;
		my $words = shift;
		
		my %words;
		for (@$words){
			$words{length $_}{$_}++;
		}
		
		$self->{words} = \%words;
	}
	
	sub complete{
		my $self = shift;
		
		$self->sorting_templates_words();
		my $geometry = $self->get_geometry();
		if ($self->check() && $self->fill(0, $geometry)){
			return $geometry;
		}
		
		return undef;
	}
	
	sub sorting_templates_words{
		my $self = shift;
		my %hash = $self->get_hash();
		
		my (@sorted_templates_words, %used);
		
		$template_with_maximum_intersections = $self->{templates_words}->[0];
		for (@{$self->{templates_words}}){
			if (scalar keys %{$hash{$_->get_key}} > scalar keys %{$hash{$template_with_maximum_intersections->get_key}}){
				$template_with_maximum_intersections = $_;
			}
		}
		
		push @sorted_templates_words, $template_with_maximum_intersections;
		$used{$template_with_maximum_intersections->get_key} = 1;
		while (@sorted_templates_words != @{$self->{templates_words}}){
			my $max = 0;
			
			for (@{$self->{templates_words}}){
				if ($used{$_} != 1){
					$max_template = $_;
					last;
				}
			}
			
			for (@{$self->{templates_words}}){
				if (!$used{$_->get_key}){
					my $count = 0;
					for my $key (keys %{$hash{$_->get_key}}){
						$count++ if ($used{$key} == 1);
					}
					
					if ($count >= $max){
						$max = $count;
						$max_template = $_;
					}
				}
			}
			
			$used{$max_template->get_key} = 1;
			push @sorted_templates_words, $max_template;
		}
		
		$self->{templates_words} = \@sorted_templates_words;
	}
	
	sub check{
		my $self = shift;
		
		my @keys = keys %{$self->{words}};
		
		for (@{$self->{all_lengths}}){
			return 0 unless ($_ ~~ @keys);
		}
		
		return 1;
	}
	
	sub fill{
		my $self = shift;
		my ($position, $geometry) = @_;
		
		my @templates_words = @{$self->{templates_words}};
		return 1 if ($position == scalar (@templates_words));
		
		my %words = %{$self->{words}};
		my $word_length = $templates_words[$position]->get_length();
		my @words_correct_length = keys %{$words{$word_length}};

		for my $word (@words_correct_length){
			if ($words{$word_length}{$word} > 0 && $self->insert_word($templates_words[$position], $word, $geometry)){
				$words{$word_length}{$word} --;
				return 1 if ($self->fill($position + 1, $geometry));
				
				$self->delete_word($templates_words[$position], $geometry);
				$words{$word_length}{$word} ++;
			}
		}
		return 0;
	}
	
	sub insert_word{
		my $self = shift;
		my ($template, $word, $geometry) = @_;
		
		my @template_word = $template->get_layout();
		my @letters = split("", $word);
		
		my $i = 0;
		for (@template_word){
			my $cell = $$geometry[$$_[0]][$$_[1]];
			return 0 if ($cell->{"amount"} > 0 && $cell->{"letter"} ne $letters[$i]);
			++$i;
		}
		
		$i = 0;
		for (@template_word){
			my $cell = $$geometry[$$_[0]][$$_[1]];
			$cell->{"letter"} = $letters[$i];
			$cell->{"amount"} ++;
			++$i;
		}
		
		return 1;
	}
	
	sub delete_word{
		my $self = shift;
		my ($template, $geometry) = @_;
		
		my @template_word = $template->get_layout();
		for (@template_word){
			my $cell = $$geometry[$$_[0]][$$_[1]];
			if ($cell->{'amount'} > 1){
				$cell->{'amount'} --;
			}
			else{
				$cell->{'letter'} = "";
				$cell->{'amount'} = 0;
			}
		}
	}
	
	sub get_hash{
		my $self = shift;
		
		my %hash;
		for (my $i = 0; $i < scalar @{$self->{templates_words}} - 1; ++$i){
			for (my $j = $i + 1; $j < scalar @{$self->{templates_words}}; ++$j){
				my $template_1 = $self->{templates_words}->[$i];
				my $template_2 = $self->{templates_words}->[$j];
				
				if ($template_1->intersect($template_2)){
					$hash{$template_1->get_key}{$template_2->get_key} = 1;
					$hash{$template_2->get_key}{$template_1->get_key} = 1;
				}
			}
		}
		return %hash;
	}
	
	sub set_intersections{
		my $self = shift;
		
		for (my $i = 0; $i < scalar @{$self->{templates_words}}; ++$i){
			my $template_1 = $self->{templates_words}->[$i];
			$template_1->index($i);
			for (my $j = 0; $j < scalar @{$self->{templates_words}}; ++$j){
				my $template_2 = $self->{templates_words}->[$j];
				$template_2->index($j);
				if ($template_1->intersects($template_2)){
					$template_1->intersections->{$j} = 1;
					$template_2->intersections->{$i} = 1;
				}
			}
		}
	}
1;