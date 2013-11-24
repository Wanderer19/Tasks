use Test::MockObject;
use Test::Simple tests => 23;
use libs::Geometry;
use libs::HistoryWithGeometry;
no warnings 'layer';

sub get_history_with_geometry{
	my ($rows, $columns) = @_;
	my $mock_geometry = Test::MockObject->new(Geometry->new(rows => $rows, columns => $columns));
 
	Test::MockObject->fake_module(
									'Geometry',
									new  => sub { $mock_geometry }
							);
	$mock_geometry->set_true('save_template_word', 'delete_word', 'check_template', 'is_geometry_undefined', 'clear', 'get_matrix_geometry');
	my $history = HistoryWithGeometry->new(geometry => $mock_geometry);

	return $history;
}

sub test_1{
	my $history = get_history_with_geometry(10, 10);
	
	$history->save_template_word(0, 0, 0, 6);
	$history->save_template_word(0, 0, 5, 0);
	$history->save_template_word(5, 0, 5, 3);
	$history->save_template_word(4, 3, 9, 3);
	$history->delete_word(2, 0, 3, 0);
	$history->undo_fast_event();
	$history->undo_fast_event();
	$history->delete_word(0, 1, 0, 5);
	$history->save_template_word(5, 8, 9, 8);
	$history->save_template_word(7, 6, 7, 9);
	$history->undo_fast_event();
	$history->undo_fast_event();
	$history->undo_fast_event();
	$history->undo_fast_event();
	$history->undo_fast_event();

	my @expected_results = (
		['save_template_word', 0, 0, 0, 6], ['save_template_word', 0, 0, 5, 0], ['save_template_word', 5, 0, 5, 3], ['save_template_word', 4, 3, 9, 3],
		['delete_word', 2, 0, 3, 0], ['save_template_word', ], ['delete_word', 4, 3, 9, 3], ['delete_word', 0, 1, 0, 5], 
		['save_template_word', 5, 8, 9, 8], ['save_template_word', 7, 6, 7, 9], ['delete_word', 7, 6, 7, 9], ['delete_word', 5, 8, 9, 8], 
		['save_template_word', ], ['delete_word', 5, 0, 5, 3]
	);
	
	check($history->geometry, @expected_results);
	$history->clear();
}

sub test_2{
	my $history = get_history_with_geometry(5, 5);
	
	$history->delete_word(0, 0, 0 ,2);
	$history->save_template_word(1, 0, 1, 4);
	$history->delete_word(1, 1, 1, 2);
	$history->undo_fast_event();
	$history->save_template_word(0, 2, 4, 2);
	$history->save_template_word(3, 1, 3, 4);
	$history->undo_fast_event();
	$history->undo_fast_event();
	$history->undo_fast_event();
	my @expected_results = (
		["delete_word", 0, 0, 0, 2], ['save_template_word', 1, 0 ,1 ,4], ['delete_word', 1, 1, 1, 2], ['save_template_word', ], ['save_template_word', 0, 2, 4, 2],
		['save_template_word', 3, 1, 3, 4], ['delete_word', 3, 1, 3, 4], ['delete_word', 0, 2, 4, 2], ['delete_word', 1, 0, 1, 4]
	);
	
	check($history->geometry, @expected_results);
}
sub check{
	my ($mock_geometry, @expected_result) = @_;
	
	for my $result (@expected_result){
		my $expected_method = shift @$result;
		my @expected_args = @$result;
		my ($actual_method, $actual_args) = $mock_geometry->next_call();
		shift @$actual_args;
		ok($expected_method eq $actual_method && @expected_args ~~ @$actual_args);
	}
}		
		
test_1();
test_2();
