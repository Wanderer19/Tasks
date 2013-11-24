use Test::Simple tests => 9;
use Encode qw(encode decode);
use utf8;
use locale;
use libs::Crossword;
use libs::Geometry;
use libs::CrosswordTemplate;

my $words = ['aardwolf', 'aback', 'abacterial', 'abacus', 'abaft', 'abalone', 'abarticulation', 'abasement', 'abash', 'abatis', 'abbotship',
			'abdication', 'abhor', 'abhorrence', 'abnegation', 'abnormalcy', 'abominable', 'absentmindedness', 'abut',
			'backbreaking', 'backlog', 'bail', 'bairn', 'bait', 'balanced', 'balky', 'ball', 'ballad', 'battleground', 'beautiful',
			'ma', 'macabre', 'macadam', 'macerator', 'maddening', 'madman', 'maelstrom', 'maddeningly', 'mailbox', 'maim',
			'sabretooth', 'sac', 'saccharic', 'saint', 'salary', 'sale', 'salamander', 'sanguinary', 'savior', 'savvy', 'say',
			'pa', 'pace', 'package', 'palatable', 'palette', 'pale', 'paleontological', 'papaya', 'parenthesis', 'pare', 'passed', 'patter',
			'zeal', 'zealot', 'zeroing', 'zip', 'zombie', 'zone', 'zinc', 'zoology', 'gentelmen',
			'wacky', 'walkout', 'walkover', 'walkthrough', 'walkway', 'wall', 'warning', 'warp', 'waterbed', 'waterbottle', 'weakness',
			'xenomania', 'xenophobia', 'xmas', 'xylograph', 'xylography', 'xylonite',
			'rabid', 'race', 'racecar', 'racecourse', 'racehorse', 'racemate', 'radioactive', 'radioallergosorbent', 'radiochemistry',
			'cabal', 'cabman', 'calcium', 'calculate', 'calf', 'cancel', 'candle', 'candy', 'candid', 'capitol', 'capacity', 'capitalization',
			'dab', 'dactylogram', 'damn', 'dampening', 'dandelion', 'dam', 'damage', 'damnation', 'dawdle', 'dawn', 'daze', 'day',
			'fa', 'fab', 'fabler', 'face', 'faculty', 'faddist', 'fading', 'fallaciousness', 'fallen', 'false', 'farewell', 'fathomless',
			'vampire', 'dragon', 'werewolf', 'dementor', 'mermaid', 'ghost', 'death', 'wizard', 'spell', 'phoenix', 'unicorn', 'prisoner']; 
			
my $additional_words = [ 'abc', 'all', 'abt', 'aby', 'for', 'ace', 'act', 'acv', 'add', 'bus', 'adj', 'fee', 'ado', 'ads', 'man',
						'adz', 'afb', 'aft', 'age', 'ago', 'aha', 'ahh', 'aid', 'ail', 'aim', 'air', 'ait', 'aka', 'akc', 'ale',
						'but', 'map', 'alp', 'aly', 'ama', 'due', 'amp', 'and', 'ann', 'for', 'ant', 'anx', 'any', 'ape',
						'app', 'art', 'apr', 'apt', 'apt', 'act', 'arc', 'arc', 'are', 'arg', 'ark', 'arm', 'art', 'yet', 'ash',
						'ash', 'can', 'ash', 'ask', 'pai', 'asp', 'one', 'par', 'ate', 'atm', 'log', 'aug', 'auk', 'car', 'aux', 'ave',
						'avg', 'awe', 'awl', 'awn', 'axe', 'out', 'pay', 'end', 'job', 'bad', 'bag', 'box', 'bam', 'ban', 'bar',
						'fee', 'bat', 'hut', 'bay', 'off', 'bed', 'bee', 'tea', 'beg', 'fit', 'bet', 'bib', 'bid', 'gun', 'big',
						'bim', 'bin', 'bio', 'bit', 'leg', 'gap', 'boa', 'bob', 'bog', 'bom', 'boo', 'way', 'bow', 'box', 'boy',
						'bpi', 'bps', 'cap'
						];
ok($_) for (	create_test(7, 8, $words, [[0, 0, 0, 7], [0, 2, 6, 2], [4, 2, 4, 5], [6, 2, 6, 5]], "yes"),
				create_test(6, 6, $words, [[0, 0, 0, 5], [0, 5, 5, 5], [5, 1, 5, 5], [2, 3, 5, 3]], "yes"),
				create_test(5, 5, $words, [[0, 0, 0, 4], [0, 0, 1, 0], [0, 4, 2, 4], [2, 3, 2, 4]], "no"),
				create_test(5, 5, ["ab", "ac", "rty", "q", "sdfg"], [[0, 0, 0, 4], [0, 4, 4, 4], [3, 2, 3, 4]], "no"),
				create_test(11, 15, $words, [[0, 7, 0, 14], [1, 8, 1, 11], [0, 9, 6, 9], [6, 9, 6, 12], [6, 11, 10, 11], [3, 0, 3, 9]], "yes"),
				create_test(16, 12, $words, [[0, 5, 6, 5], [5, 3, 15, 3], [6, 10, 9, 10], [8, 0, 12, 0], [1, 4, 1, 5], [5, 3, 5, 6], [8, 0, 8, 11]], "yes"),
				create_test(3, 3, $words, [[0, 0, 0, 2], [0, 0, 2, 0], [2, 0, 2, 2], [0, 2, 2, 2]], "no"),
				create_test(3, 3, $additional_words, [[0, 0, 0, 2], [0, 0, 2, 0], [2, 0, 2, 2], [0, 2, 2, 2]], "yes"),
				create_test(3, 3, $additional_words, [[0, 0, 0, 2], [0, 0, 2, 0], [2, 0, 2, 2], [0, 2, 2, 2], [0, 1, 2, 1], [1, 0, 1, 2]], "yes")
			);

sub create_test{
	my ($rows, $columns, $words, $coordinates_words, $mark) = @_;
	
	my $templates_words = get_templates_words($coordinates_words);
	
	my $geometry_crossword = Geometry->new(rows => $rows, columns => $columns, templates_words => $templates_words);
	my $crossword = new Crossword($geometry_crossword, $words);
	my $geometry = $crossword->complete();
	
	return check_filled_crossword($geometry, $crossword->{rows}, $crossword->{columns}, $words, $templates_words) if ($mark eq "yes");
	return !(defined $geometry) if ($mark eq "no");
}

sub get_templates_words{
	my $coordinates_words = shift;

	my @templates_words;
	for (@$coordinates_words){
		$new_template = new CrosswordTemplate(@$_);
		push @templates_words, $new_template;
	}
	
	return \@templates_words;
}

sub check_filled_crossword{
	my ($geometry, $rows, $columns, $words, $templates_words) = @_;

	for my $i (0 .. $rows - 1){
		for my $j (0 .. $columns - 1){
			my $cell = $$geometry[$i][$j];
			unless ($cell->{"mark"}){
				return 0 if($cell->{"letter"});
			}
			else{
				return 0 unless($cell->{"letter"});
			}
		}
	}
	return 0 unless(words_from_list(@_));
	return 1;
}

sub words_from_list{
	my ($geometry, $rows, $columns, $words, $templates_words) = @_;
	
	my @cells;
	
	for my $template (@$templates_words){
		my $word = "";
		for ($template->get_layout){
			my $cell = $$geometry[$$_[0]][$$_[1]];
			$word .= $cell->{"letter"};
			push @cells, "$$_[0], $$_[1]";
		}
		
		return 0 unless ($word ~~ @$words);
	}

	for my $i (0 .. $rows){
		for my $j (0 .. $columns){
			unless ("$i, $j" ~~ @cells){
				my $cell = $$geometry[$i][$j];
				return 0 if ($cell->{"letter"});
			}
		}
	}
	
	return 1;
}
